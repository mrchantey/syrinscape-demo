// using Unity.Entities;
// using UnityEngine;
// using UnityEngine.Networking;

// namespace SyrinscapeDemo
// {

//     public class LongPollSystem : SystemBase
//     {



//         double lastTime = 0;
//         float pollInterval = 3;

//         UnityWebRequest request;
//         UnityWebRequestAsyncOperation requestOperation;

//         protected override void OnCreate()
//         {
//             MakeRequest();
//         }

//         protected override void OnUpdate()
//         {
//             var dt = Time.ElapsedTime - lastTime;
//             if (dt > pollInterval)
//             {
//                 MakeRequest();
//             }
//             if (request != null && requestOperation.isDone)
//             {
//                 // Debug.Log($"UpdateBulletSystem - done");
//                 // Debug.Log($"UpdateBulletSystem - {request.downloadHandler.text}");
//                 var data = JsonUtility.FromJson<RequestData>(request.downloadHandler.text);
//                 int weaponIndex;
//                 if (!int.TryParse(data.weaponType, out weaponIndex))
//                     weaponIndex = 0;

//                 World.GetExistingSystem<PlayerShootSystem>().currentWeapon = weaponIndex;

//                 // Debug.Log($"UpdateBulletSystem - {weaponIndex}");

//                 request = null;
//                 requestOperation = null;
//             }

//         }

//         void MakeRequest()
//         {
//             request = UnityWebRequest.Get("http://13.210.246.148:7000/weapon");
//             requestOperation = request.SendWebRequest();
//             lastTime = Time.ElapsedTime;
//             // Debug.Log($"UpdateBulletSystem - requesting...");
//         }

//     }
// }