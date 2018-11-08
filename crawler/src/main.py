import requests
from bs4 import BeautifulSoup

URL = 'http://applicant-test.us-east-1.elasticbeanstalk.com/'
s = requests.Session()


def fetch(url, data=None):
  if data is None:
      return s.get(url).content
  else:
      return s.post(url, data=data).content


def change_token(token):
        token_lst = list(token)

        replacements = {
            'a': 'z',
            'b': 'y',
            'c': 'x',
            'd': 'w',
            'e': 'v',
            'f': 'u',
            'g': 't',
            'h': 's',
            'i': 'r',
            'j': 'q',
            'k': 'p',
            'l': 'o',
            'm': 'n',
            'n': 'm',
            'o': 'l',
            'p': 'k',
            'q': 'j',
            'r': 'i',
            's': 'h',
            't': 'g',
            'u': 'f',
            'v': 'e',
            'w': 'd',
            'x': 'c',
            'y': 'b',
            'z': 'a'
        }

        for idx, t in enumerate(token_lst):
            if t in replacements:
                token_lst[idx] = replacements[t]

        return ''.join(token_lst)


soup = BeautifulSoup(fetch(URL), 'html.parser')

token = soup.find(id='token')['value']
#print("\n### Token original: %s" % token)
        
jtoken = change_token(token)
#print("### Token alterado: %s\n" % jtoken)

formdata = { 'token': jtoken }

r = BeautifulSoup(fetch(URL, formdata), 'html.parser')
retorno = r.find(id="answer").getText()

print("\n### RESULTADO: %s \n" % retorno)