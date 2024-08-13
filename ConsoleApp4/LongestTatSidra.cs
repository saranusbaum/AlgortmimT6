using System;
using System.Collections.Generic;

class Sequence
{
    public List<char> Seq { get; private set; }

    public Sequence(List<char> seq)
    {
        Seq = seq;
    }

    public Sequence WithoutLast()
    {
        return new Sequence(Seq.GetRange(0, Seq.Count - 1));
    }

    public char this[int index]
    {
        get { return Seq[index - 1]; } // Indexing starts from 1
    }

    public int Length
    {
        get { return Seq.Count; }
    }

    public override string ToString()
    {
        return new string(Seq.ToArray());
    }
}

class Program2
{
    static int globalCallCount = 0;

    static Sequence LcsRecursive(Sequence X, Sequence Y)
    {
        globalCallCount++;

        if (X.Length == 0 || Y.Length == 0)
        {
            return new Sequence(new List<char>());
        }

        if (X[X.Length] == Y[Y.Length])
        {
            var lcs = LcsRecursive(X.WithoutLast(), Y.WithoutLast());
            lcs.Seq.Add(X[X.Length]);
            return lcs;
        }

        var lcs1 = LcsRecursive(X.WithoutLast(), Y);
        var lcs2 = LcsRecursive(X, Y.WithoutLast());

        return lcs1.Length > lcs2.Length ? lcs1 : lcs2;
    }

    static void Main2(string[] args)
    {
        var X = new Sequence(new List<char> { 'A', 'B', 'C', 'B', 'D', 'A', 'B' });
        var Y = new Sequence(new List<char> { 'B', 'D', 'C', 'A', 'B', 'A' });

        globalCallCount = 0;
        var result = LcsRecursive(X, Y);
        Console.WriteLine("LCS: " + result.ToString());
        Console.WriteLine("Number of recursive calls: " + globalCallCount);

        // דוגמאות נוספות
        var inputs = new List<(Sequence, Sequence)>
        {
            (new Sequence(new List<char> { 'A', 'B', 'C' }), new Sequence(new List<char> { 'A', 'C', 'B' })),
            (new Sequence(new List<char> { 'A', 'A', 'A', 'A' }), new Sequence(new List<char> { 'A', 'B', 'A', 'B' })),
            (new Sequence(new List<char> { 'A', 'B', 'C', 'D', 'E' }), new Sequence(new List<char> { 'A', 'C', 'B', 'D', 'E' }))
        };

        for (int i = 0; i < inputs.Count; i++)
        {
            globalCallCount = 0;
            var (X1, Y1) = inputs[i];
            result = LcsRecursive(X1, Y1);
            Console.WriteLine($"Test {i + 1}: LCS: {result.ToString()}, Number of recursive calls: {globalCallCount}");
        }
    }
}
