using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class ItemView : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private TMP_Text _label;
    [SerializeField] private Button _selectionButton;

    private ItemData _itemData;

    public event UnityAction<ItemData> ItemSelected;
    public event UnityAction<ItemView> ItemDisabled;

    private void OnEnable()
    {
        _selectionButton.onClick.AddListener(OnSelectionButtonClick);
    }

    private void OnDisable()
    {
        ItemDisabled?.Invoke(this);
        _selectionButton.onClick.RemoveListener(OnSelectionButtonClick);
    }

    private void OnSelectionButtonClick()
    {
        ItemSelected?.Invoke(_itemData);
    }

    public void Initialize(ItemData itemData)
    {
        _itemData = itemData;
        _image.sprite = itemData.Preview;
        _label.text = itemData.label;
    }

}
