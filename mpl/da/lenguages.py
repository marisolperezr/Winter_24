text_pl = '''Chiny powinny ponieść „wyższe koszty” za wspieranie Rosji w wojnie z Ukrainą, stwierdziła nowa szefowa polityki zagranicznej UE Kaja Kallas.
Była premier Estonii rozmawiała z eurodeputowanymi podczas trzygodzinnego przesłuchania przed objęciem urzędu, kiedy jako priorytet określiła zwycięstwo Ukrainy – mocniejsze słowa niż niejasne formuły wsparcia wyrażane przez część unijnych polityków.
„Zwycięstwo Ukrainy jest dla nas wszystkich priorytetem; sytuacja na polu bitwy jest bardzo trudna” – powiedziała Kallas posłom do Parlamentu Europejskiego w uwagach wstępnych. „Dlatego musimy kontynuować pracę każdego dnia, dziś, jutro i tak długo, jak będzie to konieczne, korzystając z takiej pomocy wojskowej, finansowej i humanitarnej, jaka będzie potrzebna”.
'''.lower()
text_sp='''
China debería enfrentar “un costo mayor” por apoyar a Rusia en la guerra contra Ucrania, dijo la nueva jefa de política exterior de la UE, Kaja Kallas.
La ex primera ministra estonia hablaba ante los eurodiputados durante una audiencia de tres horas antes de asumir el cargo, cuando mencionó la victoria de Ucrania como una prioridad: palabras más fuertes que las fórmulas más vagas de apoyo expresadas por algunos políticos de la UE.
“La victoria de Ucrania es una prioridad para todos nosotros; la situación en el campo de batalla es muy difícil”, dijo Kallas a los eurodiputados en su discurso de apertura. "Por eso debemos seguir trabajando todos los días, hoy, mañana y durante el tiempo que sea necesario, y con tanta ayuda militar, financiera y humanitaria como sea necesario".
'''.lower()

text_en='''
China should face “a higher cost” for supporting Russia in the war against Ukraine, the EU’s incoming foreign policy chief, Kaja Kallas, has said.
The former Estonian prime minister was speaking to MEPs during a three-hour hearing before she takes office, when she listed Ukraine’s victory as a priority – stronger words than vaguer formulas of support voiced by some EU politicians.
“Victory of Ukraine is a priority for us all; the situation on the battlefield is very difficult,” Kallas told MEPs in her opening remarks. “That is why we must keep on working every day, today, tomorrow and for as long as it takes, and with as much military, financial and humanitarian aid as neededz.”
'''.lower()


def get_frequency(text) :
    letters = sorted(list(set(list(text))))
    letters_dict = dict.fromkeys(letters, 0)
    for letter in text:
        letters_dict[letter]+=1
    return letters_dict, letters

print('------ Polish -------')
result_pl, letters_pl = get_frequency(text_pl)
for letter in letters_pl:
    if letter.isalpha():
        print("%5s %5.2f" %(letter,(100*result_pl[letter]/len(text_pl)) ))

print('------ English -------')
result_en, letters_en = get_frequency(text_en)
for letter in letters_en:
    if letter.isalpha():
        print("%5s %5.2f" %(letter,(100* result_en[letter])/len(text_en)) )

print('------ Spanish -------')
result_sp, letters_sp = get_frequency(text_sp)
for letter in letters_sp:
    if letter.isalpha():
        print("%5s %5.2f" %(letter,(100* result_sp[letter]/len(text_sp)) ))


