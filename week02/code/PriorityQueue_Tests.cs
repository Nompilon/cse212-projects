using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue multiple items and Dequeue one.
    // Expected Result: The item with the highest priority is returned.
    // Defect(s) Found: None
    public void TestPriorityQueue_EnqueueAndDequeue_HighestPriorityReturned()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("Medium", 5);
        priorityQueue.Enqueue("High", 10);

        var dequeued = priorityQueue.Dequeue();
        Assert.AreEqual("High", dequeued);
    }

    [TestMethod]
    // Scenario: Enqueue items with same highest priority, latest added should be dequeued.
    // Expected Result: Last item with highest priority is dequeued.
    // Defect(s) Found: None
    public void TestPriorityQueue_SamePriority_LastAddedDequeued()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("First", 5);
        priorityQueue.Enqueue("Second", 10);
        priorityQueue.Enqueue("Third", 10); // Should be dequeued because it's last with highest priority

        var dequeued = priorityQueue.Dequeue();
        Assert.AreEqual("Third", dequeued);
    }

    [TestMethod]
    // Scenario: Dequeue from empty queue.
    // Expected Result: Throws InvalidOperationException
    // Defect(s) Found: None
    [ExpectedException(typeof(InvalidOperationException))]
    public void TestPriorityQueue_EmptyQueue_ThrowsException()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Dequeue();
    }

    [TestMethod]
    // Scenario: Ensure items are removed after Dequeue
    // Expected Result: Second highest priority returned next
    // Defect(s) Found: None
    public void TestPriorityQueue_Dequeue_RemovesItemCorrectly()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("One", 3);
        priorityQueue.Enqueue("Two", 7);
        priorityQueue.Enqueue("Three", 5);

        var first = priorityQueue.Dequeue(); // "Two"
        var second = priorityQueue.Dequeue(); // "Three"

        Assert.AreEqual("Two", first);
        Assert.AreEqual("Three", second);
    }
}