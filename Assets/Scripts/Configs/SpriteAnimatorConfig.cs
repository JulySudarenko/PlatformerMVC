using System;
using System.Collections.Generic;
using UnityEngine;


namespace Platformer
{
     [CreateAssetMenu(fileName = "SpriteAnimatorCnf", menuName = "Configs/SpriteAnimatorCnf", order = 0)]
    public class SpriteAnimatorConfig : ScriptableObject
    {
        [Serializable]
        public sealed class SpriteSeguence
        {
            public AnimState Track;
            public List<Sprite> Sprites = new List<Sprite>();
        }
        public List<SpriteSeguence> Seguences = new List<SpriteSeguence>();
    }
}