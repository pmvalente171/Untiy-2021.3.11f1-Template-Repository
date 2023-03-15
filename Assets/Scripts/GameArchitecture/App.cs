using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Object = UnityEngine.Object;

namespace GameArchitecture
{
    public class App : GenericSingletonClass<App>
    {
        // [Header("Input Manager")]
        // [SerializeField] private InputProvider provider = null;


        private void Start()
        {
#if UNITY_EDITOR
            switch (SceneManager.GetActiveScene().buildIndex)
            {
                case 0:
                    // main menu
                    // TODO : Remove this later
                    // provider.ChangeCurrentState(InputProvider.CreateGameplayMiddleWare());
                    break;
                default:
                    // it's a gameplay scene
                    // provider.ChangeCurrentState(InputProvider.CreateGameplayMiddleWare());
                    break;
            } 
#else
            // Load the default manner
            // provider.ChangeCurrentState(InputProvider.CreateNoInput());
#endif
        }

        /// <summary>
        /// This method is called
        /// before the scene is loaded
        /// And it will load all main
        /// Components that are needed
        /// to run the game 
        /// </summary>
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void Bootstrap()
        {
            if (Instantiate(Resources.Load("App")) is not GameObject app)
                throw new ApplicationException();

#if UNITY_EDITOR
            switch (SceneManager.GetActiveScene().buildIndex)
            {
                case 0:
                    // main menu
                break;
                default:
                    // it's a gameplay scene
                    break;
            } 
#else
            // Load the default manner
#endif
        }

        // public void ChangeCurrentState(List<InputMiddleware> newValue) => provider.ChangeCurrentState(newValue);
        
        // public void ChangeCurrentState(InputMiddleware newValue) => provider.ChangeCurrentState(newValue);
    }
}