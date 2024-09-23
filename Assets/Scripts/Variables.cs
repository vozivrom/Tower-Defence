using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Variable
{
    public class Variables : MonoBehaviour
    {
        public static bool isMusicOn = false, areEffectsOn = false;
        public static  Image _banner;
        public static int coins = 100;
        public static string active_gunplace;
        public static List<float> speed = new List<float>(3) {0.05f, 0.01f, 2};
        public static List<float> damage = new List<float>(3) {0.5f, 2, 5};
        //public static List<byte> range = new List<byte>(3) {};
    }
}