using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CreatureCrawler.Utils {
    public static class Utils {

        private static System.Random rng = new System.Random();

        public static T getRandomElement<T>(this IEnumerable<T> list) {
            return list.OrderBy(i => rng.Next()).First();
        }

        public static List<T> getManyRandomElements<T>(this IEnumerable<T> list, int number) {
            return list.OrderBy(i => rng.Next()).Take(number).ToList();
        }

        public static IEnumerable<TSource> Also<TSource>(this IEnumerable<TSource> source, Action<TSource> selector) {
            source.ToList().ForEach(i => selector(i));
            return source;
        }

        public static List<T> Shuffled<T>(this List<T> list) {
            return list.OrderBy(x => Guid.NewGuid()).ToList();
        }

        public static T AddAndGetComponent<T>(this GameObject parent) where T : Component {
            parent.AddComponent<T>();
            return parent.GetComponent<T>();
        }

        public static void AssignSpriteFromPath(this GameObject gameObj, string path) {
            gameObj.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(path);
        }

        /// <summary>
        /// This will calculate center points for elements to be spaced out horizontally within a container.
        /// Once the container width is reached, the margin between elements will shrink in order to keep all elements
        /// evenly spaced.
        /// Container width can be tricky to get right, so toy around with the settings until it looks right. Calculations
        /// seem to be working fine, so I have a feeling this is more likely due to some UI / World spacing discrepancy I'm not aware of.
        /// </summary>
        public static List<Vector2> getCenterPointsInHorizontalSpread(
            Vector2 containerCenter,
            float containerWidth,
            int numElements,
            float elementWidth,
            float marginRatio=0.1f // the margin that will attempt to buffer two elements compared to elementWidth
        ) {
            var centers = new List<Vector2>();
            var widthWithMargins = (elementWidth + (elementWidth * marginRatio) * 2) * numElements;
            if (widthWithMargins <= containerWidth || containerWidth == float.MaxValue) { // try to center elements with their margins around the center point if it fits in the container
                var leftMostElementCenter =
                    containerCenter - // from the center...
                    new Vector2(widthWithMargins / 2, 0) + // go to the left of the total elements' span
                    new Vector2((elementWidth / 2) + (elementWidth * marginRatio), 0); // and then go right a single margin and half of an element width
                for (var i = 0; i < numElements; i++) {
                    centers.Add(
                        leftMostElementCenter +
                        new Vector2( i * (elementWidth + (elementWidth * marginRatio) * 2),0)
                    );
                }
            }
            else {
                var sectionWidth = containerWidth / numElements;
                var leftBorder = containerCenter - new Vector2(containerWidth / 2, 0);
                for (var i = 0; i < numElements; i++) {
                    centers.Add(
                        leftBorder +
                        new Vector2(sectionWidth * i + (sectionWidth / 2),0)
                    );
                }
            }
            return centers;
        }
    }
}