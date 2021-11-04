using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Managers
{
    public class LevelManager : MonoBehaviour
    {

        // Start is called before the first frame update
        void Awake()
        {
            App.levelManager = this;
        }
    }
}
