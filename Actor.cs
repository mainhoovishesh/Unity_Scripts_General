using UnityEngine;

// This class contains general information describing an actor (player or enemies).
// It is mostly used for AI detection logic and determining if an actor is friend or foe
public class Actor : MonoBehaviour
{
    //[Tooltip("Represents the affiliation (or team) of the actor. Actors of the same affiliation are friendly to eachother")]
    public int affiliation;
    //Represents point where other actors will aim when they attack this actor
    public Transform aimPoint;
    //this is for the advanced character controller in an FPS game 
    ActorsManager m_ActorsManager;

    private void Start()
    {
        //here the actor manager takes the game object for example the player or the enemy   
        m_ActorsManager = GameObject.FindObjectOfType<ActorsManager>();
        DebugUtility.HandleErrorIfNullFindObject<ActorsManager, Actor>(m_ActorsManager, this);

        // Register as an actor 
        //here the actor is put into the empty Plot
        if (!m_ActorsManager.actors.Contains(this))
        {
            m_ActorsManager.actors.Add(this); 
        }
    }

    private void OnDestroy()
    {
        // Unregister as an actor
        if (m_ActorsManager)
        {
            m_ActorsManager.actors.Remove(this);
        }
    }
}
