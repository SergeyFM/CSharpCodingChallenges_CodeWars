using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenges;
[TestClass]
public class The_Supermarket_Queue {
    [TestMethod]
    public void Test() {
        /*

        There is a queue for the self-checkout tills at the supermarket. Your task is write a function to calculate the total time required for all the customers to check out!

        input
        customers: an array of positive integers representing the queue. Each integer represents a customer, and its value is the amount of time they require to check out.
        n: a positive integer, the number of checkout tills.
        output
        The function should return an integer, the total time required.

        queueTime([5,3,4], 1)
        // should return 12
        // because when there is 1 till, the total time is just the sum of the times

        queueTime([10,2,3,3], 2)
        // should return 10
        // because here n=2 and the 2nd, 3rd, and 4th people in the 
        // queue finish before the 1st person has finished.

        queueTime([2,3,10], 2)
        // should return 12

        Clarifications
        There is only ONE queue serving many tills, and
        The order of the queue NEVER changes, and
        The front person in the queue (i.e. the first element in the array/list) proceeds to a till as soon as it becomes free.

        */

        long expected = 10;
        long actual = QueueTime(new int[] { 1, 2, 3, 4 }, 1);
        Assert.AreEqual(expected, actual);

        expected = 9;
        actual = QueueTime(new int[] { 2, 2, 3, 3, 4, 4 }, 2);
        Assert.AreEqual(expected, actual);

        expected = 5;
        actual = QueueTime(new int[] { 1, 2, 3, 4, 5 }, 100);
        Assert.AreEqual(expected, actual);

    }

    public static long QueueTime(int[] customers, int n) {
        int[] tills = new int[n];
        foreach (int c in customers) {
            int ind = Array.IndexOf(tills, tills.Min());
            tills[ind] += c;
        }
        return (long)tills.Max();
    }

}
