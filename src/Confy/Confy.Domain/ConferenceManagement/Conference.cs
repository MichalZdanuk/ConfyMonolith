﻿using Confy.Domain.ConferenceManagement.ValueObjects;

namespace Confy.Domain.ConferenceManagement;
public class Conference : Aggregate
{
	private readonly List<Guid> _lectureIds = new();
	public IReadOnlyList<Guid> LectureIds => _lectureIds.AsReadOnly();
	public string Name { get; private set; } = default!;
	public string Language { get; private set; } = default!;
	public ConferenceLinks ConferenceLinks { get; private set; } = default!;
	public ConferenceDetails ConferenceDetails { get; private set; } = default!;
	public Address Address { get; private set; } = default!;

	public static Conference Create(Guid id,
		string name,
		string language,
		ConferenceLinks conferenceLinks,
		ConferenceDetails details,
		Address address)
	{
		var conference = new Conference
		{
			Id = id,
			Name = name,
			Language = language,
			ConferenceLinks = conferenceLinks,
			ConferenceDetails = details,
			Address = address
		};

		return conference;
	}

	public void Update(string name,
		string language,
		ConferenceLinks conferenceLinks,
		ConferenceDetails details,
		Address address)
	{
		Name = name;
		Language = language;
		ConferenceLinks = conferenceLinks;
		ConferenceDetails = details;
		Address = address;
	}

	public void AddLecture(Guid lectureId)
	{
		if (!_lectureIds.Contains(lectureId))
		{
			_lectureIds.Add(lectureId);
		}
	}

	public void RemoveLecture(Guid lectureId)
	{
		if (_lectureIds.Contains(lectureId))
		{
			_lectureIds.Remove(lectureId);
		}
	}
}
