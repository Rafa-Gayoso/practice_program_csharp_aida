using System;

namespace LegacySecurityManager;

public class UserData {

    private readonly string _username;
    private readonly string _fullName;
    private readonly string _password;
    private readonly string _confirmPassword;

    public UserData(string username, string fullName, string password, string confirmPassword) {
        _username = username;
        _fullName = fullName;
        _password = password;
        _confirmPassword = confirmPassword;
    }

    public string Password() {
        return _password;
    }

    public string ConfirmPassword() {
        return _confirmPassword;
    }

    public string UserName() {
        return _username;
    }

    public string FullName() {
        return _fullName;
    }

    protected bool Equals(UserData other)
    {
        return _username == other._username && _fullName == other._fullName && _password == other._password && _confirmPassword == other._confirmPassword;
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((UserData)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(_username, _fullName, _password, _confirmPassword);
    }

    public override string ToString()
    {
        return
            $"{nameof(_username)}: {_username}, {nameof(_fullName)}: {_fullName}, {nameof(_password)}: {_password}, {nameof(_confirmPassword)}: {_confirmPassword}";
    }
}