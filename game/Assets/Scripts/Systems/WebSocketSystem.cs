using Unity.Entities;
using UnityEngine;
using UnityEngine.InputSystem;
using WebSocketSharp;
//https://medium.com/unity-nodejs/websocket-client-server-unity-nodejs-e33604c6a006
//https://channels.readthedocs.io/en/stable/tutorial/part_1.html

namespace SyrinscapeDemo
{

    public class WebSocketSystem : SystemBase
    {
        WebSocket webSocket;
        string ip = "3.104.110.97";
        string port = "7000";
        // string url = "ws://localhost:8080";
        protected override void OnCreate()
        {
            string url = $"ws://{ip}:{port}/socket";
            webSocket = new WebSocket(url);
            webSocket.Connect();
            webSocket.OnMessage += OnMessage;
        }


        void OnMessage(object sender, MessageEventArgs args)
        {
            var data = JsonUtility.FromJson<RequestData>(args.Data);
            int weaponIndex;
            if (!int.TryParse(data.weaponType, out weaponIndex))
                weaponIndex = 0;

            int enemyIndex;
            if (!int.TryParse(data.enemyType, out enemyIndex))
                enemyIndex = 0;

            World.GetExistingSystem<PlayerShootSystem>().currentWeapon = weaponIndex;
            World.GetExistingSystem<SpawnEnemySystem>().currentEnemey = enemyIndex;
            World.GetExistingSystem<SpawnEnemySystem>().spawnNextFrame = true;

        }

        protected override void OnUpdate()
        {
            // if (webSocket == null)
            // {
            // 	return;
            // }
            // if (Keyboard.current.spaceKey.isPressed)
            // {
            // 	webSocket.Send("Hello");
            // }
        }
    }
}