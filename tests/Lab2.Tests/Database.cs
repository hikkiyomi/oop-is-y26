using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

[CollectionDefinition("Database collection")]
public class Database : ICollectionFixture<DatabaseFixture>
{
}