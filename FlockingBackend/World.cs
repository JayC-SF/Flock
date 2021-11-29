using System.Collections.Generic;

namespace FlockingBackend
{
    /// <summary>
    /// The <c>World</c> class encapsulates the fields and methods of the Monogame world environment 
    /// </summary>
    public class World
    {
        /// <summary>
        /// InitialCount represents the initial number of sparrows in World
        /// </summary>
        public static int InitialCount { get; private set; }

        /// <summary>
        /// Width represents the Width of the window
        /// </summary>
        public static int Width { get; }

        /// <summary>
        /// Height represents the Height of the window
        /// </summary>
        public static int Height { get; }

        /// <summary>
        /// MaxSpeed represents the maximum speed of a Sparrow object
        /// </summary>
        public static float MaxSpeed { get; }

        /// <summary>
        /// NeighbourRadius is the radius to check if theres a neighbouring bird
        /// </summary>
        public static float NeighbourRadius { get; }

        /// <summary>
        /// NeighbourRadius is the radius to check if a bird is too close
        /// </summary>
        public static float AvoidanceRadius { get; }

        /// <summary>
        /// NeighbourRadius is the radius to check if a bird is too close
        /// </summary>
        public static float ChasingRadius { get; }

        /// <summary>
        /// NeighbourRadius is the radius to check if a bird is too close
        /// </summary>
        public static float FleeRadius { get; }

        /// <summary>
        /// Sparrows is a list of all the Sparrow objects that will be displayed during the Monogame project
        /// </summary>
        public List<Sparrow> Sparrows { get; }

        /// <summary>
        /// Raven is an instance of the Raven object that chases the Sparrows
        /// </summary>
        public Raven Raven { get; }

        /// <summary>
        /// flockObj is a Flock object that handles all the events of each Bird
        /// </summary>
        private Flock flockObj;

        /// <summary>
        /// Static Constructor to initialize the static fields of World object
        /// </summary>
        static World()
        {
            InitialCount = 150; //number of sparrows
            Width = 1000; //Width of the canvas (“world”)
            Height = 500; //Height of the canvas
            MaxSpeed = 4; //Max speed of the birds
            NeighbourRadius = 100; //Radius used to determine if a bird is a neighbour
            AvoidanceRadius = 25; //Radius used to determine if a bird is too close
            FleeRadius = 50;
            ChasingRadius = 65;
        }

        /// <summary>
        /// Default Constructor to initialize the Sparrows and Ravens at a random position of the Monogame project
        /// </summary>
        public World()
        {
            this.flockObj = new Flock();
            this.Sparrows = new List<Sparrow>();
            for (int i = 0; i < InitialCount; i++)
            {
                Sparrow sparrowObj = new Sparrow(); //TO-DO: maybe inherit from Bird object?
                flockObj.Subscribe(sparrowObj.CalculateBehaviour, sparrowObj.Move, sparrowObj.CalculateRavenAvoidance);
                this.Sparrows.Add(sparrowObj);
            }
            this.Raven = new Raven(); //also maybe inherit from Bird?
            flockObj.Subscribe(Raven.CalculateBehaviour, Raven.Move);
        }

        /// <summary>
        /// Update() method invokes all the events of the Flock object (both list of Flock objects and Raven)
        /// </summary>
        /// <param name="sparrows"></param>
        /// <param name="raven"></param>
        public void Update()
        {
            flockObj.RaiseMoveEvents(Sparrows, Raven);
        }
    }
}