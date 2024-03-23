﻿namespace Domain;

using System.Dynamic;
using System.Net.Mail;

public class Colaborator : IColaborator
{
    private string _strName;
    private string _strEmail;

    public Colaborator(string strName, string strEmail) {

		if( isValidParameters(strName, strEmail) ) {
			_strName = strName;
			_strEmail = strEmail;
		}
		else
			throw new ArgumentException("Invalid arguments.");
	}

	public bool isValidParameters(string strName, string strEmail) {

		if(string.IsNullOrWhiteSpace(strName) ||
			strName.Length > 50 ||
			ContainsAny(strName, ["0", "1", "2", "3", "4", "5", "6", "7", "8", "9"]))
			return false;

		if( !IsValidEmailAddres( strEmail ) )
			return false;
		
		return true;
	}

	private bool ContainsAny(string stringToCheck, params string[] parameters)
	{
		return parameters.Any(parameter => stringToCheck.Contains(parameter));
	}

	// from https://mailtrap.io/blog/validate-email-address-c/
	private bool IsValidEmailAddres(string email)
	{
		var valid = true;

		try
		{
			var emailAddress = new MailAddress(email);
		}
		catch
		{
			valid = false;
		}

		return valid;
	}

	public string GetName() {
		return _strName;
	}

	public string GetEmail() {
		return _strEmail;
	}

}

