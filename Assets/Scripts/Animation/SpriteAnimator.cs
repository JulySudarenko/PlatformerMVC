using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    internal class SpriteAnimator : IExecute, ICleanup
    {
        private sealed class Animation
        {
            public AnimState Track;
            public List<Sprite> Sprites;
            public float Speed = 10.0f;
            public float Counter = 0.0f;
            public bool Loop = true;
            public bool Sleep;

            public void Execuite(float deltaTime)
            {
                if (Sleep) return;
                Counter += deltaTime * Speed;

                if (Loop)
                {
                    while (Counter > Sprites.Count)
                    {
                        Counter -= Sprites.Count;
                    }
                }
                else if (Counter > Sprites.Count)
                {
                    Counter = Sprites.Count;
                    Sleep = true;
                }
            }
        }

        private SpriteAnimatorConfig _config;
        private Dictionary<SpriteRenderer, Animation> _activeAnimations;
        
        public SpriteAnimator(SpriteAnimatorConfig config)
        {
            _config = config;
            _activeAnimations = new Dictionary<SpriteRenderer, Animation>();
        }

        public void StartAnimation(SpriteRenderer spriteRenderer, AnimState track, bool loop, float speed)
        {
            if (_activeAnimations.TryGetValue(spriteRenderer, out var animation))
            {
                animation.Loop = loop;
                animation.Speed = speed;
                animation.Sleep = false;
                if (animation.Track != track)
                {
                    animation.Track = track;
                    animation.Sprites = _config.Seguences.Find(sequence => sequence.Track == track).Sprites;
                    animation.Counter = 0;
                }
            }
            else
            {
                _activeAnimations.Add(spriteRenderer, new Animation()
                    {
                        Track = track,
                        Sprites = _config.Seguences.Find(sequence => sequence.Track == track).Sprites,
                        Loop = loop,
                        Speed = speed
                    });
            }
        }

        public void StopAnimation(SpriteRenderer sprite)
        {
            if (_activeAnimations.ContainsKey(sprite))
            {
                _activeAnimations.Remove(sprite);
            }
        }

        public void Execute(float deltaTime)
        {
            foreach (var anime in _activeAnimations)
            {
                 anime.Value.Execuite(deltaTime);
                 if (anime.Value.Counter < anime.Value.Sprites.Count)
                 {
                     anime.Key.sprite = anime.Value.Sprites[(int) anime.Value.Counter];
                 }
            }
        }

        public void Cleanup()
        {
            _activeAnimations.Clear();
        }
    }
}
