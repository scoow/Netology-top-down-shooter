using UnityEngine;

public class FolowerUpdate : Follower
{
    private void Update()
    {
        Move(Time.deltaTime);
    }
}