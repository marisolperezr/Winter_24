    
    
texto_or = 'María Soledad Pérez Ruiz'.lower()
lista = sorted(set(list(texto_or)))

contador=[0]*len(lista)
for letra in texto_or:
    if letra in lista : 
        indice = lista.index(letra)
        contador[indice]+=1
for i in range (len(lista)):
    print(f" '{lista[i]}' : '{contador[i]}'")