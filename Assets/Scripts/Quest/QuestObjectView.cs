using Platformer;
using UnityEngine;

namespace PlatformerMVC
{
    public class QuestObjectView : TriggerContacts
    {
        public SpriteRenderer SpriteRenderer;
        [SerializeField] private Color _completedColor;
        [SerializeField] private int _id;

        private Color _defaultColor;

        public int Id => _id;
        
        #region Unity methods

        private void Awake()
        {
            _defaultColor = SpriteRenderer.color;
        }

        #endregion

        #region Methods

        public void ProcessComplete()
        {
            SpriteRenderer.color = _completedColor;
        }

        public void ProcessActivate()
        {
            SpriteRenderer.color = _defaultColor;
        }

        #endregion
    }
}

