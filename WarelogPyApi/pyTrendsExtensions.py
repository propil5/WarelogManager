import numpy as np
from pytrends.request import TrendReq

def GetTrendingOverTime(keyword):
    kw_list = [keyword]
    pytrends = TrendReq(hl='pl-PL', tz=360)
    pytrends.build_payload(kw_list, cat=0, timeframe='today 12-m', geo='', gprop='')
    print(pytrends.interest_over_time())
    return pytrends.interest_over_time().to_json()