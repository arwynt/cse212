using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Add three items with different priorities to the queue.
    // Expected Result: The item with the highest priority is returned first.
    // Defect(s) Found: The loop did not check the last item in the queue, so the highest-priority item could be missed.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("Apple", 1);
        priorityQueue.Enqueue("Banana", 3);
        priorityQueue.Enqueue("Cherry", 2);

        var result = priorityQueue.Dequeue();

        Assert.AreEqual("Banana", result);
    }

    [TestMethod]
    // Scenario: Add two items with the same priority to the queue.
    // Expected Result: The item added first is returned first.
    // Defect(s) Found: The comparison used >=, which caused the later item with the same priority to be selected instead of the first item.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("Apple", 5);
        priorityQueue.Enqueue("Banana", 5);

        var result = priorityQueue.Dequeue();

        Assert.AreEqual("Apple", result);
    }

    [TestMethod]
    // Scenario: Add two items with different priorities and dequeue twice.
    // Expected Result: The highest-priority item is returned first and removed, then the next-highest-priority item is returned.
    // Defect(s) Found: The Dequeue function returned the highest-priority item but did not remove it from the queue.
    public void TestPriorityQueue_DequeueRemovesItem()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("Apple", 5);
        priorityQueue.Enqueue("Banana", 3);

        Assert.AreEqual("Apple", priorityQueue.Dequeue());
        Assert.AreEqual("Banana", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Attempt to dequeue from an empty priority queue.
    // Expected Result: An InvalidOperationException is thrown with the message "The queue is empty."
    // Defect(s) Found: No defect found. The empty queue correctly throws the required InvalidOperationException with the correct message.
    public void TestPriorityQueue_Empty()
    {
        var priorityQueue = new PriorityQueue();

        var exception = Assert.ThrowsException<InvalidOperationException>(
            () => priorityQueue.Dequeue());

        Assert.AreEqual("The queue is empty.", exception.Message);
    }
}