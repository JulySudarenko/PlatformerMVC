using UnityEngine;


namespace Platformer
{
    public static class BuildAssistant
    {
        public static GameObject AddTransform(this GameObject gameObject, Transform transform)
        {
            gameObject.transform.position = transform.position;
            return gameObject;
        }

        public static T GetOrAddComponent<T>(this GameObject gameObject) where T : Component
        {
            var result = gameObject.GetComponent<T>();
            if (!result)
            {
                result = gameObject.AddComponent<T>();
            }

            return result;
        }
    }
}
