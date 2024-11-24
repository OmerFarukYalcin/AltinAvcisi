using NUnit.Framework;
using UnityEngine;

public class MovementTest
{
    // Test to validate horizontal movement
    [Test]
    public void HorizontalTest()
    {
        // Create an instance of the PlayerController
        var player = new PlayerController();

        // Calculate the horizontal movement value
        float x = player.CalculateMovementVector(1, 0, 10, 1).x;

        // Assert that the calculated value matches the expected value
        Assert.AreEqual(10, x, "Horizontal movement did not match the expected value.");
    }

    // Test to validate vertical movement
    [Test]
    public void VerticalTest()
    {
        // Create an instance of the PlayerController
        var player = new PlayerController();

        // Calculate the vertical movement value
        float z = player.CalculateMovementVector(0, 1, 10, 1).z;

        // Assert that the calculated value matches the expected value
        Assert.AreEqual(10, z, "Vertical movement did not match the expected value.");
    }
}
