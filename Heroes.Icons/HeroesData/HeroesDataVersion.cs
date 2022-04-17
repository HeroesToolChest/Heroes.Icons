namespace Heroes.Icons.HeroesData;

/// <summary>
/// Contains the information for a heroes-data version number.
/// See <see href="https://github.com/HeroesToolChest/heroes-data"/>.
/// </summary>
public class HeroesDataVersion : IComparable, IComparable<HeroesDataVersion>, IEquatable<HeroesDataVersion>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="HeroesDataVersion"/> class.
    /// </summary>
    /// <param name="major">The first number of the version.</param>
    /// <param name="minor">The second number of the version.</param>
    /// <param name="revision">The third number of the version.</param>
    /// <param name="build">The fourth number of the version.</param>
    /// <param name="isPtr">Value indicating if the version is a ptr version.</param>
    public HeroesDataVersion(int major, int minor, int revision, int build, bool isPtr = false)
    {
        if (major < 0) major = 0;
        if (minor < 0) minor = 0;
        if (revision < 0) revision = 0;
        if (build < 0) build = 0;

        Major = major;
        Minor = minor;
        Revision = revision;
        Build = build;
        IsPtr = isPtr;
    }

    /// <summary>
    /// Gets the major value (first).
    /// </summary>
    public int Major { get; }

    /// <summary>
    /// Gets the minor value (second).
    /// </summary>
    public int Minor { get; }

    /// <summary>
    /// Gets the revision value (third).
    /// </summary>
    public int Revision { get; }

    /// <summary>
    /// Gets the build value (fourth).
    /// </summary>
    public int Build { get; }

    /// <summary>
    /// Gets a value indicating whether it's a ptr version.
    /// </summary>
    public bool IsPtr { get; }

    /// <summary>
    /// Compares the <paramref name="left"/> value to the <paramref name="right"/> value and determines if they are equal.
    /// </summary>
    /// <param name="left">The left hand side of the operator.</param>
    /// <param name="right">The right hand side of the operator.</param>
    /// <returns><see langword="true"/> if the <paramref name="left"/> value is equal to the <paramref name="right"/> value; otherwise <see langword="false"/>.</returns>
    public static bool operator ==(HeroesDataVersion? left, HeroesDataVersion? right)
    {
        if (left is null)
            return right is null;
        return left.Equals(right);
    }

    /// <summary>
    /// Compares the <paramref name="left"/> value to the <paramref name="right"/> vlaue and determines if they are not equal.
    /// </summary>
    /// <param name="left">The left hand side of the operator.</param>
    /// <param name="right">The right hand side of the operator.</param>
    /// <returns><see langword="true"/> if the <paramref name="left"/> value is not equal to the <paramref name="right"/> value; otherwise <see langword="false"/>.</returns>
    public static bool operator !=(HeroesDataVersion? left, HeroesDataVersion? right)
    {
        return !(left == right);
    }

    /// <summary>
    /// Compares the <paramref name="left"/> value to the <paramref name="right"/> value and determines if the <paramref name="left"/> value is less than the <paramref name="right"/> value.
    /// </summary>
    /// <param name="left">The left hand side of the operator.</param>
    /// <param name="right">The right hand side of the operator.</param>
    /// <returns><see langword="true"/> if the <paramref name="left"/> value is less than the <paramref name="right"/> value; otherwise <see langword="false"/>.</returns>
    public static bool operator <(HeroesDataVersion? left, HeroesDataVersion? right)
    {
        return left is null ? right is object : left.CompareTo(right) < 0;
    }

    /// <summary>
    /// Compares the <paramref name="left"/> value to the <paramref name="right"/> value and determines if the <paramref name="left"/> value is less than or equal to the <paramref name="right"/> value.
    /// </summary>
    /// <param name="left">The left hand side of the operator.</param>
    /// <param name="right">The right hand side of the operator.</param>
    /// <returns><see langword="true"/> if the <paramref name="left"/> value is less than or equal to the <paramref name="right"/> value; otherwise <see langword="false"/>.</returns>
    public static bool operator <=(HeroesDataVersion? left, HeroesDataVersion? right)
    {
        return left is null || left.CompareTo(right) <= 0;
    }

    /// <summary>
    /// Compares the <paramref name="left"/> value to the <paramref name="right"/> value and determines if the <paramref name="left"/> value is greater than the <paramref name="right"/> value.
    /// </summary>
    /// <param name="left">The left hand side of the operator.</param>
    /// <param name="right">The right hand side of the operator.</param>
    /// <returns><see langword="true"/> if the <paramref name="left"/> value is greater than the <paramref name="right"/> value; otherwise <see langword="false"/>.</returns>
    public static bool operator >(HeroesDataVersion? left, HeroesDataVersion? right)
    {
        return left is object && left.CompareTo(right) > 0;
    }

    /// <summary>
    /// Compares the <paramref name="left"/> value to the <paramref name="right"/> value and determines if the <paramref name="left"/> value is greater than or equal to the <paramref name="right"/> value.
    /// </summary>
    /// <param name="left">The left hand side of the operator.</param>
    /// <param name="right">The right hand side of the operator.</param>
    /// <returns><see langword="true"/> if the <paramref name="left"/> value is greater than or equal to the <paramref name="right"/> value; otherwise <see langword="false"/>.</returns>
    public static bool operator >=(HeroesDataVersion? left, HeroesDataVersion? right)
    {
        return left is null ? right is null : left.CompareTo(right) >= 0;
    }

    /// <summary>
    /// Converts a string representation of the heroes-data version number into <see cref="HeroesDataVersion"/>.
    /// </summary>
    /// <param name="s">The string representation of the heroes-data version number.</param>
    /// <param name="result">When this method returns, contains the version number in a <see cref="HeroesDataVersion"/>.</param>
    /// <returns><see langword="true"/> if <paramref name="s"/> was converted; otherwise <see langword="false"/>.</returns>
    public static bool TryParse(string? s, [NotNullWhen(true)] out HeroesDataVersion? result)
    {
        result = null;

        return ParseVersionString(s, ref result);
    }

    /// <summary>
    /// Converts a span representation of the heroes-data version number into <see cref="HeroesDataVersion"/>.
    /// </summary>
    /// <param name="s">The span representation of the heroes-data version number.</param>
    /// <param name="result">When this method returns, contains the version number in a <see cref="HeroesDataVersion"/>.</param>
    /// <returns><see langword="true"/> if <paramref name="s"/> was converted; otherwise <see langword="false"/>.</returns>
    public static bool TryParse(ReadOnlySpan<char> s, [NotNullWhen(true)] out HeroesDataVersion? result)
    {
        result = null;

        return ParseVersionString(s, ref result);
    }

    /// <summary>
    /// Converts a string representation of the heroes-data version number into <see cref="HeroesDataVersion"/>.
    /// </summary>
    /// <param name="s">The string representation of the heroes-data version number.</param>
    /// <returns>The version number in <see cref="HeroesDataVersion"/>.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="s"/> is <see langword="null"/>.</exception>
    /// <exception cref="FormatException"><paramref name="s"/> is not in a valid format.</exception>
    public static HeroesDataVersion Parse(string s)
    {
        if (s is null)
            throw new ArgumentNullException(nameof(s));

        if (TryParse(s, out HeroesDataVersion? value))
            return value;
        else
            throw new FormatException("Invalid format");
    }

    /// <summary>
    /// Converts a span representation of the heroes-data version number into <see cref="HeroesDataVersion"/>.
    /// </summary>
    /// <param name="s">The span representation of the heroes-data version number.</param>
    /// <returns>The version number in <see cref="HeroesDataVersion"/>.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="s"/> is <see langword="null"/>.</exception>
    /// <exception cref="FormatException"><paramref name="s"/> is not in a valid format.</exception>
    public static HeroesDataVersion Parse(ReadOnlySpan<char> s)
    {
        if (s == null)
            throw new ArgumentNullException(nameof(s));

        if (TryParse(s, out HeroesDataVersion? value))
            return value;
        else
            throw new FormatException("Invalid format");
    }

    /// <inheritdoc/>
    public int CompareTo([AllowNull] HeroesDataVersion other)
    {
        if (other is null)
            return 1;

        int valueCompare = Major.CompareTo(other.Major);
        if (valueCompare != 0)
            return valueCompare;

        valueCompare = Minor.CompareTo(other.Minor);
        if (valueCompare != 0)
            return valueCompare;

        valueCompare = Revision.CompareTo(other.Revision);
        if (valueCompare != 0)
            return valueCompare;

        valueCompare = Build.CompareTo(other.Build);
        if (valueCompare != 0)
            return valueCompare;

        if (IsPtr == other.IsPtr)
            return 0;
        else if (other.IsPtr)
            return -1;
        else
            return 1;
    }

    /// <inheritdoc/>
    public int CompareTo(object? obj)
    {
        if (ReferenceEquals(this, obj))
            return 0;
        if (obj is null)
            return 1;

        if (obj is not HeroesDataVersion heroesDataVersion)
            throw new ArgumentException($"{nameof(obj)} is not a {nameof(HeroesDataVersion)}");
        else
            return CompareTo(heroesDataVersion);
    }

    /// <inheritdoc/>
    public bool Equals([AllowNull] HeroesDataVersion other)
    {
        if (other is null)
            return false;

        return Major == other.Major &&
            Minor == other.Minor &&
            Revision == other.Revision &&
            Build == other.Build &&
            IsPtr == other.IsPtr;
    }

    /// <inheritdoc/>
    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(this, obj))
            return true;
        if (obj is null)
            return false;

        if (obj is not HeroesDataVersion heroesDataVersion)
            return false;
        else
            return Equals(heroesDataVersion);
    }

    /// <inheritdoc/>
    public override int GetHashCode()
    {
        return HashCode.Combine(Major, Minor, Revision, Build, IsPtr);
    }

    /// <inheritdoc/>
    public override string ToString()
    {
        if (IsPtr)
            return $"{Major}.{Minor}.{Revision}.{Build}_ptr";
        else
            return $"{Major}.{Minor}.{Revision}.{Build}";
    }

    private static bool ParseVersionString(ReadOnlySpan<char> value, [NotNullWhen(true)] ref HeroesDataVersion? result)
    {
        if (value == null || value.IsEmpty)
            return false;

        string sString = value.ToString();

        string[] values = sString.Split('.', StringSplitOptions.RemoveEmptyEntries);

        if (values.Length != 4)
            return false;

        if (int.TryParse(values[0], out int major) &&
            int.TryParse(values[1], out int minor) &&
            int.TryParse(values[2], out int revision))
        {
            int indexPtr = values[3].IndexOf('_', StringComparison.OrdinalIgnoreCase);

            int build;

            if (indexPtr > 0)
            {
                ReadOnlySpan<char> buildSpan = values[3].AsSpan();

                if (int.TryParse(buildSpan.Slice(0, indexPtr), out build) &&
                    buildSpan[(indexPtr + 1)..].Equals("ptr", StringComparison.OrdinalIgnoreCase))
                {
                    result = new HeroesDataVersion(major, minor, revision, build, true);
                    return true;
                }
            }
            else if (int.TryParse(values[3], out build))
            {
                result = new HeroesDataVersion(major, minor, revision, build);
                return true;
            }
        }

        return false;
    }
}
