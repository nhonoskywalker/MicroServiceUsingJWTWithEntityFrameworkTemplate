
namespace BusinessCard.Insfrastructure.Logger
{
    using System;

    public interface ILogger
    {
        void WriteException(Exception e);
    }
}
