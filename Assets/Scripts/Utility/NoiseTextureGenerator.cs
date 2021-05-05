#pragma warning disable 0649

using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace TurnBasedRPG
{
    public static class NoiseTextureGenerator
    {
        private static Texture2D texture;

        private static int[] hash = { 7, 3, 15, 8, 1, 6, 0, 2 };

        private const int length = 7;

        private static int resolution = 128;
        private static int frequency = 16;

        [MenuItem("Noise Texture2D", menuItem = "GameObject/Textures/Noise", priority = 8, validate = false)]
        private static void Create()
        {
            texture = new Texture2D(resolution, resolution, TextureFormat.RGB24, true);

            texture.name = $"Noise-Texture2D-{resolution}x{resolution}";

            texture.wrapMode = TextureWrapMode.Clamp;
            texture.filterMode = FilterMode.Point;

            float step = 1f / resolution;

            Vector3 topLeft = new Vector3(-1f, 1f);
            Vector3 topRight = new Vector3(1f, 1f);
            Vector3 bottomLeft = new Vector3(-1f, -1f);
            Vector3 bottomRight = new Vector3(1f, -1f);

            for (int y = 0; y < resolution; y++)
            {
                Vector3 left = Vector3.Lerp(bottomLeft, topLeft, (y + 0.5f) * step);
                Vector3 right = Vector3.Lerp(bottomRight, topRight, (y + 0.5f) * step);

                for (int x = 0; x < resolution; x++)
                {
                    Vector3 point = Vector3.Lerp(left, right, (x) * step);

                    //Debug.Log(point);

                    texture.SetPixel(x, y, Color.white * Random.Range(0f, 1f));
                }
            }

            texture.Apply();

            SaveTextureToAssets();
        }

        private static float CalculateRandomNoise(Vector3 point)
        {
            point *= frequency;

            int x = Mathf.FloorToInt(point.x) & length;
            int y = Mathf.FloorToInt(point.y) & length;

            return hash[(hash[x] + y) & length] * (1f / length);
        }

        private static void SaveTextureToAssets()
        {
            File.WriteAllBytes(Application.dataPath + "/Materials/Textures/" + texture.name + ".png", texture.EncodeToPNG());

            AssetDatabase.Refresh();
        }
    }
}
