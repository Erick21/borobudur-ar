using UnityEngine;
using TMPro;

public class MyBadgesItemHandler : MonoBehaviour
{
    [SerializeField] public GameObject bgImage, avatarImage, levelImage, questionmark;//, starImage1, starImage2, starImage3, starImage4, starImage5;
    [SerializeField] public TMP_Text levelText, titleText;
    public string achievementID;

    // dicky add this
    public GameObject[] starImages;
    Transform _anchorPoint;
    int _position;
    bool _isInitialized;

    void OnEnable()
    {
        if (!_isInitialized) Invoke("Initialize", 1);
    }

    void Initialize()
    {
        _isInitialized = true;
    }

    public void SetAnchorPoint (Transform anchor, int pos)
    {
        _anchorPoint = anchor;
        _position = pos;
    }

    public void SetUnachieved()
    {
        questionmark.SetActive(true);

        gameObject.GetComponent<UnityEngine.UI.Image>().enabled = false;

        foreach (Transform item in avatarImage.transform.parent)
            item.GetComponent<UnityEngine.UI.Image>().color /= 2;
    }
    
    void LateUpdate()
    {
        if (_isInitialized && Vector3.Distance(_anchorPoint.position, transform.position) > .01f)
            transform.position = new Vector3(
                _anchorPoint.position.x,
                Mathf.Lerp(transform.position.y, _anchorPoint.position.y, Time.deltaTime * 3f - (_position / 1000f)),
                _anchorPoint.position.z
            );
    }
}