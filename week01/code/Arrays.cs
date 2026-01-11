using System.Collections.Generic;

public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  
    /// For example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  
    /// Assume that length is a positive integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // Step-by-step plan:
        // 1. Create a new array of doubles with exactly 'length' slots.
        // 2. The first element (index 0) is number × 1.
        // 3. Each subsequent element is number × (i + 1).
        // 4. Fill the array using a simple for loop.
        // 5. Return the completed array.

        double[] result = new double[length];

        for (int i = 0; i < length; i++)
        {
            result[i] = number * (i + 1);
        }

        return result;
    }

    /// <summary>
    /// Rotate the data to the right by the 'amount'.  
    /// Example: data = {1,2,3,4,5,6,7,8,9}, amount = 3 → becomes {7,8,9,1,2,3,4,5,6}
    /// The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// This function modifies the existing list in-place.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // Step-by-step plan:
        // 1. Handle trivial cases: empty list or single element → no rotation needed
        // 2. Normalize rotation using modulo: effectiveAmount = amount % data.Count
        //    (handles full rotations like amount == data.Count)
        // 3. Extract last 'effectiveAmount' elements (they move to front)
        // 4. Extract first (n - effectiveAmount) elements (they move to end)
        // 5. Clear original list and rebuild in rotated order

        if (data == null || data.Count <= 1)
            return;

        int n = data.Count;
        int effectiveAmount = amount % n;

        if (effectiveAmount == 0)
            return;

        // Get the two slices
        List<int> lastPart = data.GetRange(n - effectiveAmount, effectiveAmount);
        List<int> firstPart = data.GetRange(0, n - effectiveAmount);

        // Rebuild: rotated part first, then remaining part
        data.Clear();
        data.AddRange(lastPart);
        data.AddRange(firstPart);
    }
}