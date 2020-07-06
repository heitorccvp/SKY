using System;
using System.Collections.Generic;
using System.Text;

namespace SKY.Infra.Shared.Util
{
	public static class TratamentoData
	{
		public static int intervaloDeMinutos(DateTime dateTime1, DateTime dateTime2)
		{
			TimeSpan t1 = new TimeSpan(dateTime1.Day, dateTime1.Hour, dateTime1.Minute, dateTime1.Second);
			TimeSpan t2 = new TimeSpan(dateTime2.Day, dateTime2.Hour, dateTime2.Minute, dateTime2.Second);

			TimeSpan intervalo = t2 - t1;

			return intervalo.Minutes;
		}
	}
}
