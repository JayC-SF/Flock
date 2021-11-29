using System.Collections.Generic;
namespace FlockingBackend
{
    /// <summary>
    /// This delegate type will store methods to calculate the 
    /// moving vector for an entity (i.e Raven or Sparrow)
    /// </summary>
    /// <param name="sparrows">List of sparrows as input</param>
    public delegate void CalculateMoveVector(List<Sparrow> sparrows);
    /// <summary>
    /// This delegate type holds methods to notify a Bird entity to move.
    /// </summary>
    public delegate void MoveBird();
    /// <summary>
    /// This delegate type holds method to notify a Sparrow to calculate
    /// the amount to steer from a Raven that might be following a sparrow.
    /// </summary>
    /// <param name="raven">Raven object</param>
    public delegate void CalculateRavenAvoidance(Raven raven);
}