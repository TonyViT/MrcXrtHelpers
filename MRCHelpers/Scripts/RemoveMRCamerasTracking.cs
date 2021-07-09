using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SpatialTracking;

namespace MRCHelpers
{

    /// <summary>
    /// Removes the tracked pose driver in the cameras used for mixed reality capture.
    /// Unity automatically adds it, and this way, the cameras follow the head of the 
    /// user, while they should be fixed in the world
    /// </summary>
    public class RemoveMRCamerasTracking : MonoBehaviour
    {
        /// <summary>
        /// Start
        /// </summary>
        private IEnumerator Start()
        {
            //the names of the cameras that Oculus adds for MRC
            string[] camerasNames = new string[] { "OculusMRC_BackgroundCamera", "OculusMRC_ForgroundCamera" };
            Transform tr = null;

            //let everything initialize
            yield return null;

            //for each camera
            foreach (string cameraName in camerasNames)
            {
                //find it, and destroy its TrackedPoseDriver when it gets added
                yield return new WaitUntil(() => (tr = transform.Find(cameraName)) != null);
                yield return new WaitUntil(() => tr.GetComponent<TrackedPoseDriver>() != null);
                Destroy(tr.GetComponent<TrackedPoseDriver>());
            }

        }
    }

}