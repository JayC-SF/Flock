using System.Collections.Generic;

namespace FlockingBackend
{
    ///<summary>
    ///This class is the subscriber class that each bird subscribes to. The class also raises the events to calculate movement vector and move the birds.
    ///</summary>
    public class Flock
    {
        /// <summary>
        /// Events that will get invoked on the Subscribe() method to direct the Bird movement
        /// </summary>
        private event CalculateMoveVector CalcMovementEvent;
        private event MoveBird MoveEvent;
        private event CalculateRavenAvoidance CalcRavenFleeEvent;

        /// <summary>
        /// Subscribe() method takes in 3 delegate params and assigns it to the proper event
        /// </summary>
        /// <param name="calcMoveDel"></param>
        /// <param name="calcRavenFleeDel"></param>
        /// <param name="moveDel"></param>
        public void Subscribe(CalculateMoveVector calcMoveDel, MoveBird moveDel, CalculateRavenAvoidance calcRavenFleeDel = null)
        {
            CalcMovementEvent += calcMoveDel;
            MoveEvent += moveDel;
            if (calcRavenFleeDel != null)
            {
                CalcRavenFleeEvent += calcRavenFleeDel;
            }
        }

        ///<summary>
        ///This method raises the calculate and move events
        ///</summary>
        ///<param name="sparrows">List of Sparrow objects</param>
        ///<param name="raven">A Raven object</param>
        public void RaiseMoveEvents(List<Sparrow> sparrows, Raven raven)
        {
            if (sparrows != null) {
                CalcMovementEvent?.Invoke(sparrows);
                if (raven != null) {
                CalcRavenFleeEvent?.Invoke(raven);
                }
            }
            MoveEvent?.Invoke();
        }
    }
}