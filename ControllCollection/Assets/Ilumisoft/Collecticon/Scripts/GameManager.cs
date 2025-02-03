using Ilumisoft.Collecticon.Core;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Ilumisoft.Collecticon
{
    public class GameManager : SingletonBehaviour<GameManager>
    {
        private SceneManager sceneManager;

        private LevelManager levelManager;

        private Player player;

        bool isGameOver = false;

        public GameObject AdPanel;

        private bool isRevive;

        public void SetAdPanel(bool a)
        {
            AdPanel.SetActive(a);
            Time.timeScale = a == true ? 0 : 1;
        }

        public void Revive()
        {
            AdManager.ShowVideoAd("192if3b93qo6991ed0",
            (bol) => {
                if (bol)
                {
                    StopCoroutine("GameOver");
                    player.SetPos();
                    SetAdPanel(false);

                    AdManager.clickid = "";
                    AdManager.getClickid();
                    AdManager.apiSend("game_addiction", AdManager.clickid);
                    AdManager.apiSend("lt_roi", AdManager.clickid);


                }
                else
                {
                    StarkSDKSpace.AndroidUIManager.ShowToast("观看完整视频才能获取奖励哦！");
                }
            },
            (it, str) => {
                Debug.LogError("Error->" + str);
                //AndroidUIManager.ShowToast("广告加载异常，请重新看广告！");
            });
        }

        public void CancelAd()
        {
            SetAdPanel(false);
        }

        public IEnumerator GameOver()
        {
            yield return new WaitForSeconds(0.2f);
            if (!isGameOver /*&& !isRevive*/)
            {
                isGameOver = true;

                Time.timeScale = 0.0f;

                sceneManager.LoadScene(sceneManager.CurrentScene.name);


                AdManager.ShowInterstitialAd("1lcaf5895d5l1293dc",
                    () => {
                        Debug.Log("--插屏广告完成--");

                    },
                    (it, str) => {
                        Debug.LogError("Error->" + str);
                    });
            }
        }



        public void PreGameOver()
        {
            SetAdPanel(true);
            StartCoroutine("GameOver");
        }

        protected override void Awake()
        {
            base.Awake();

            levelManager = FindObjectOfType<LevelManager>();
            sceneManager = FindObjectOfType<SceneManager>();
            if(GameObject.FindObjectOfType<Player>()==null)
            {
                return;
            }
            player = GameObject.FindObjectOfType<Player>().GetComponent<Player>();
        }

        private void Start()
        {
            isGameOver = false;

            // Make sure to unpause game time
            Time.timeScale = 1.0f;
        }

        /// <summary>
        /// Finish the current level and load the next one
        /// </summary>
        public void Finish()
        {
            if (isGameOver)
            {
                return;
            }

            isGameOver = true;

            this.InvokeDelayed(LoadNextLevelOrMainMenu, delay: 1f);


            AdManager.ShowInterstitialAd("1lcaf5895d5l1293dc",
                () => {
                    Debug.Log("--插屏广告完成--");

                },
                (it, str) => {
                    Debug.LogError("Error->" + str);
                });
        }

        /// <summary>
        /// Loads the next level or returns to the main menu if there is none
        /// </summary>
        void LoadNextLevelOrMainMenu()
        {
            // Load the next level if there is one
            if (levelManager.HasNextLevel())
            {
                levelManager.LoadNextLevel();
            }
            // Otherwise go to the main menu
            else
            {
                sceneManager.LoadScene(0);
            }
        }

        /// <summary>
        /// Restarts the current level to give the player another chance
        /// </summary>

    }
}