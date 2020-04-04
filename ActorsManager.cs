using System.Collections.Generic;
using UnityEngine;
//this script acts as the actor manager of the actor(Player or the enemy
public class ActorsManager : MonoBehaviour
{
    public List<Actor> actors { get; private set; }

    private void Awake()
    {
        actors = new List<Actor>();
    }
}
