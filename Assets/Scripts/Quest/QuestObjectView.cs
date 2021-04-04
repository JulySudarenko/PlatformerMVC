using Platformer;
using UnityEngine;

namespace Platformer
{
    public class QuestObjectView : TriggerContacts
    {
        public SpriteRenderer SpriteRenderer;
        [SerializeField] private Color _completedColor;
        [SerializeField] private int _id;

        private Color _defaultColor;

        public int Id => _id;

        private void Awake()
        {
            _defaultColor = SpriteRenderer.color;
        }
        public void ProcessComplete()
        {
            SpriteRenderer.color = _completedColor;
        }

        public void ProcessActivate()
        {
            SpriteRenderer.color = _defaultColor;
        }
    }
}

