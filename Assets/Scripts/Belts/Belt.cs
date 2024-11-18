using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Belt : MonoBehaviour
{
    private static int _beltID = 0;

    public Belt beltInSequence;
    public BeltItem beltItem;
    public bool isItemOnBelt;

    private BeltManager _beltManager;

    private void Start()
    {
        _beltManager = FindObjectOfType<BeltManager>();
        beltInSequence = null;
        beltInSequence = FindNextBelt();
        gameObject.name = $"Belt_{_beltID++}";
    }

    private void Update()
    {
        if (beltInSequence == null)
        {
            beltInSequence = FindNextBelt();
        }

        if (beltInSequence != null && beltItem.item != null)
        {
            StartCoroutine(MoveItem());
        }
    }

    public Vector3 GetItemPosition()
    {
        var padding = 0.5f;
        var position = transform.position;
        return new Vector3(position.x + padding, position.y + padding);
    }

    private IEnumerator MoveItem()
    {
        isItemOnBelt = true;

        if (beltItem.item != null && beltInSequence != null && beltInSequence.isItemOnBelt == false)
        {
            Vector3 toPosition = beltInSequence.GetItemPosition();

            beltInSequence.isItemOnBelt = true;

            var step = _beltManager.speed * Time.deltaTime;

            while (beltItem.item.transform.position != toPosition)
            {
                beltItem.item.transform.position = Vector3.MoveTowards(beltItem.item.transform.position, toPosition, step);

                yield return null;
            }

            isItemOnBelt = false;
            beltInSequence.beltItem = beltItem;
            beltItem = null;
        }
    }

    private Belt FindNextBelt()
    {
        Transform currentBeltTransform = transform;

        var forward = transform.forward;

        Ray ray = new(currentBeltTransform.position, forward);

        if (Physics.Raycast(ray, out RaycastHit hit, 1f))
        {
            Belt belt = hit.collider.GetComponent<Belt>();

            if (belt != null)
            {
                return belt;
            }
        }

        return null;
    }
}