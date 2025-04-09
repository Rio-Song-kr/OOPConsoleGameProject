namespace OOPConsoleGameProject;

public struct Note
{
    public Tone ToneValue;
    public Duration DurationValue;

    public Note(Tone frequency, Duration time)
    {
        ToneValue = frequency;
        DurationValue = time;
    }
}