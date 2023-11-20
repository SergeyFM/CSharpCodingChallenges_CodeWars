using System;

namespace CodingChallenges;
[TestClass]
public class Sum_The_Tree {
    /*

    Sum The Tree

    Given a node object representing a binary tree,
    write a function that returns the sum of all values, including the root. Absence of a node will be indicated with a null value.

    Examples:

    10
    | \
    1  2
    => 13

    1
    | \
    0  0
        \
         2
    => 3

    */

    [TestMethod]
    public void Test() {
        var tree = new Node(10, new Node(1), new Node(2));
        Assert.AreEqual(13, SumTree(tree));
        Assert.AreEqual(13, SumTree_v2(tree));
        tree = new Node(11, new Node(0), new Node(0, null, new Node(1)));
        Assert.AreEqual(12, SumTree(tree));
        Assert.AreEqual(12, SumTree_v2(tree));
    }

    public static int SumTree(Node root) {
        int sum = root.Value;
        if (root.Left is not null) sum += SumTree(root.Left);
        if (root.Right is not null) sum += SumTree(root.Right);
        return sum;
    }

      public static int SumTree_v2(Node root) => root == null 
        ? 0 
        : root.Value + SumTree(root.Left) + SumTree(root.Right);
  
}


public class Node {
    public int Value;
    public Node Left;
    public Node Right;

    public Node(int value, Node left = null, Node right = null) {
        Value = value;
        Left = left;
        Right = right;
    }
}
