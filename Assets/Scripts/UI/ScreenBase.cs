using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class ScreenBase : MonoBehaviour
    {

        public virtual void Show()
        {
            gameObject.SetActive(true);
        }

        public virtual void Show(Dictionary<string, object> parameter=null)
        {
            gameObject.SetActive(true);
        }

        public virtual void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}
