using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public RectTransform valueRectTransform;
    public float _currentValue = 100;

    public GameObject gameplayUI;
    public GameObject gameOverScreen;

    private float _maxValue;
    void Start()
    {
        _maxValue = _currentValue;
       UpdateHealthbar();
    }

    private void Update()
    {
        /*        _currentValue -= 0.1f;
                if (_currentValue <= 0)
                {
                    Destroy(gameObject);
                }
                Debug.LogWarning(_currentValue);
                UpdateHealthbar();*/
    }

    public void TakeDamage(float damage)
    {

            _currentValue -= damage;
            if (_currentValue <= 0)
            {
                PlayerSdox();
            }
           
            UpdateHealthbar();
    }

    void UpdateHealthbar()
    {
        valueRectTransform.anchorMax = new Vector2(_currentValue / _maxValue, 1);
    }

    private void PlayerSdox ()
    {
        gameOverScreen.SetActive(true);
        gameplayUI.SetActive(false);
        GetComponent<PlayerController>().enabled = false;
        GetComponent<FireballCaster>().enabled = false;
        GetComponent<CameraRotation>().enabled = false;
    }
}
