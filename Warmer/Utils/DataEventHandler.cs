namespace Warmer.Utils
{
    /// <summary>
    /// Delegate for an event handler sending some data along with the data sender
    /// </summary>
    /// <typeparam name="S">Type of the sender</typeparam>
    /// <typeparam name="T">Type of the data</typeparam>
    /// <param name="sender">Sender</param>
    /// <param name="data">Data</param>
    public delegate void DataEventHandler<S, T>(S sender, T data);

    /// <summary>
    /// Delegate for an event handler sending some data
    /// </summary>
    /// <typeparam name="T">Type of the data</typeparam>
    /// <param name="data">Data</param>
    public delegate void DataEventHandler<T>(T data);

    /// <summary>
    /// Delegate for an event handler sending nothing
    /// </summary>
    public delegate void DataEventHandler();
}
