using System;
using CaronixTest.Json;
using Cysharp.Threading.Tasks;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;

namespace CaronixTest.EnemyComponents
{
    public class DataLoader
    {
        public async UniTask<EnemyData> GetData(string url)
        {
            var text = await GetTextAsync(UnityWebRequest.Get(url));

            var data = JsonConvert.DeserializeObject<JsonData>(text);

            if (data == null)
                throw new NullReferenceException("Data is null");

            if (data.results.Count <= 0)
                throw new Exception("Result is empty");

            Texture2D texture = await GetTexture(UnityWebRequest.Get(data.results[0].picture.medium));
            EnemyData enemyData = new EnemyData(data.results[0].login.username, texture);
            
            return enemyData;
        }

        private async UniTask<string> GetTextAsync(UnityWebRequest webRequest)
        {
            var request = await webRequest.SendWebRequest();
            
            return request.downloadHandler.text;
        }

        private async UniTask<Texture2D> GetTexture(UnityWebRequest webRequest)
        {
            var request = await webRequest.SendWebRequest();
            
            var texture = new Texture2D(1, 1);
            texture.LoadImage(request.downloadHandler.data);

            return texture;
        }
    }
}