using UnityEngine;

namespace Ads
{
    [CreateAssetMenu]
    public class AdsConfig : ScriptableObject
    {
        [SerializeField] private string _androidGameId;
        [SerializeField] private string _iOSGameId;
        [SerializeField] private string _androidAdUnitId = "Rewarded_Android";
        [SerializeField] private string _iOSAdUnitId = "Rewarded_iOS";
        [SerializeField] private bool _testMode = false;

        public bool TestMode => _testMode;
        public string AndroidGameId => _androidGameId;
        public string IOSGameId => _iOSGameId;
        public string AndroidAdUnitId => _androidAdUnitId;
        public string IOSAdUnitId => _iOSAdUnitId;
    }
}
