using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUpMessage : MonoBehaviour
{
  private float displayTime = 0.5f;
  private float startTime;
  private Image thisImage;
  [SerializeField] private Transform playerPos;
  [SerializeField] private Sprite[] sprites;

  private RectTransform rectTransform;
  private Vector3 offset = new Vector3(0, 1f, 0);
  private Vector3 moveOffset = new Vector3(0, 50f, 0); // 上昇量を調整する
  private bool isActive = false;

  private void Start()
  {
    thisImage = GetComponent<Image>();
    rectTransform = GetComponent<RectTransform>();

    this.gameObject.SetActive(false);
  }

  private void Update()
  {
    if (isActive)
    {
      float diffTime = Time.time - startTime;
      if (diffTime < displayTime)
      {
        Vector3 startPosition = RectTransformUtility.WorldToScreenPoint(Camera.main, playerPos.position + offset);
        Vector3 targetPosition = startPosition + moveOffset;
        rectTransform.position = Vector3.Lerp(startPosition, targetPosition, diffTime/ displayTime);
      }
      else
      {
        this.gameObject.SetActive(false);
        isActive = false;
      }
    }
  }

  public void DmgPopUp()
  {
    this.gameObject.SetActive(true);
    int rand = Random.Range(0, 3);
    thisImage.sprite = sprites[rand];

    startTime = Time.time;
    isActive = true;
  }

  public void PopBarrier()
  {
    this.gameObject.SetActive(true);
    thisImage.sprite = sprites[3];

    startTime = Time.time;
    isActive = true;
  }
}
