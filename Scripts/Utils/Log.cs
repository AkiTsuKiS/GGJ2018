using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

static class Log
{
	public enum LEVEL { LOW, MIDDLE, HIGH };

	public static int DEBUG_LEVEL = (int)LEVEL.HIGH;

	private static bool init = false;
	private static string logDirectory;
	private static string logFile;
	private static string fullPath;

	private static void InitLogFile()
	{
		if (init) return;
		
		logDirectory	= Application.dataPath + @"\log";
		logFile			= DateTime.Now.ToString("yyyy-MM-dd") + ".log";
		fullPath		= Path.Combine(logDirectory, logFile);

		if (!Directory.Exists(logDirectory))
		{
			Directory.CreateDirectory(logDirectory);
		}
		if (!File.Exists(fullPath))
		{
			using (StreamWriter sw = File.CreateText(fullPath)) { }
		}

		init = true;
	}

	// Log error message (any DBG_LVL)
	public static void E(object s)
	{
		writeLog(@"[E]" + s.ToString());
		Debug.LogError(s.ToString());
	}

	// Normal log message (DBG_LVL 3+)
	public static void H(object s)
	{
		writeLog(@"[H]" + s.ToString());
	}

	public static void M(object s)
	{
		if (DEBUG_LEVEL >= (int)LEVEL.MIDDLE)
		{
			writeLog(@"[M]" + s.ToString());
		}
	}

	public static void L(object s)
	{
		if (DEBUG_LEVEL >= (int)LEVEL.LOW)
		{
			writeLog(@"[L]" + s.ToString());
		}
	}

	private static void writeLog(string s)
	{
		InitLogFile();

		string msg = DateTime.Now.ToString("HH:mm:ss.ffff") + " " + s;
		Debug.Log(msg);
		File.AppendAllText(fullPath, msg + Environment.NewLine);
	}
}
