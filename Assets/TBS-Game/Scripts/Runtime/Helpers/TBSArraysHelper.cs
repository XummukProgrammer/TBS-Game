public static class TBSArraysHelper
{
    public static void AddValueInArray<T>(ref T[] array, T value)
    {
        System.Array.Resize(ref array, array.Length + 1);
        array[array.Length - 1] = value;
    }
}
