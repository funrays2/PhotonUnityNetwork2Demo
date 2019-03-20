using UnityEngine.UI;
using UnityEngine;

using Photon.Pun;
using Photon.Realtime;

using System.Collections;

namespace Com.Dirox.MyGame
{
    [RequireComponent(typeof(InputField))]
    public class PlayerNameInputField : MonoBehaviour {

        #region Private Constants
        const string playerNamePrefKey = "PlayerName";
        #endregion

        #region MonoBahaviour CallBacks

        void Start()
        {
            string defaultName = string.Empty;
            InputField _inputField = this.GetComponent<InputField>();
            if (_inputField != null)
            {
                if (PlayerPrefs.HasKey(playerNamePrefKey))
                {
                    defaultName = PlayerPrefs.GetString(playerNamePrefKey);
                    _inputField.text = defaultName;
                }
            }
            PhotonNetwork.NickName = defaultName;
        }

        #endregion

        #region Public Methods
        
        public void SetPlayerName(string value)
        {
            //#Important
            if (string.IsNullOrEmpty(value))
            {
                Debug.LogError("Player Name is null or empty");
                return;
            }
            PhotonNetwork.NickName = value;

            PlayerPrefs.SetString(playerNamePrefKey, value);
        }

        #endregion
    }
}
