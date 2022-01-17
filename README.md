
## Intro
This is a school project. Some guidelines were given in order to accomplish it.

Note that some methods use to implement were not the most efficient due to some requirements requested by the teacher to implement various design patterns.

Thank you,

# Flocking Algorithm Adaptation


For the sake of providing a more "natural" behavior of the flocks and the raven, we decided to add more features and change some components of the algorithm. Neither the design or structure of the algorithm was changed as certain behavior required extra attention to detail to provide a more natural look.

## Adaptations 
### `World.cs` 
Some new variables in `World.cs` were added in order to provide more speicifications for the behaviour.
The `FleeRadius` and `ChasingRadius` public static getter properties have been created 
```csharp
        // Line 65-78 in World.cs
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
```
The vallues of `AvoidanceRadius` has been changed for a smaller radius since 
the adaptation in the `Sparrow.cs` (Please refer to the `Sparrow.cs` adaptation section below)

The `FleeRadius` property was set to have a smaller radius than the `ChasingRadius` in order to have the Raven a lot more active when chasing.
### `Sparrow.cs`
The `Sparrow` class received some changes at the `Avoidance()` and the `CalculateRavenAvoidance()` functions.

#### `CalculateRavenAvoidance()`
The `CalculateRavenAvoidance()` function overwrites the `amountToSteer` when a sparrow is fleeing a raven. If the sparrow is not fleing a raven then it will not overwrite the `amountToSteer`.

#### `Avoidance()`
The `Avoidance()` method does not multiply the normalized vector and perform the difference between between the avg vector anymore because it was causing the sparrow to behave in an "unnatural flock". After performing those changes the birds were not stacking on top of each other as much and the flock was having a much natural behaviour.

#### `FleeRaven()`
In the `FleeRaven()` function the sparrow speeds up in the same velocity as it was if the raven is on the same position as the current sparrow.






