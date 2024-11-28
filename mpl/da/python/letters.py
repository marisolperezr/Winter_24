
#Import the library for the chart

import matplotlib.pyplot as plt

#Same code as the teacher

def get_frequency(text):                                        
    letters = sorted(list(set(text))) 
    letters_dict = dict.fromkeys(letters, 0)  
    for letter in text:
        if letter.isalpha():                        #I added this line to only save letters
            letters_dict[letter] += 1
    return letters_dict

def show_frequency(language, file_name):
    try:
        with open(file_name, 'r', encoding='utf-8') as file:        #saw this on internet
            text = file.read().lower()  
        print(f"------ {language} -------")
        result = get_frequency(text)
    
        for letter in sorted(result):
            if letter.isalpha():                                
                print(f"{letter:5} {result[letter]:5}")
        
        #Here I return the results to show them in the chart
        return result                                               
    
    except FileNotFoundError:
        print(f"El archivo {file_name} no existe.")
        return None

def plot_chart():
   
    polish_result = show_frequency("Polish", "polish.txt")
    spanish_result = show_frequency("Spanish", "spanish.txt")
    english_result = show_frequency("English", "english.txt")
    
    #This is just to make sure that if I return nothing in show_frequency() I have nothing to show in the chart

    if polish_result is None or spanish_result is None or english_result is None:
        print("Cannot generate the chart")
        return
    
    # 
    all_letters = sorted(set(polish_result) | set(spanish_result) | set(english_result))
    
    # Chart 
    plt.style.use('fivethirtyeight')
    plt.figure(figsize=(12, 6))

    # These are the bars for each language

    polish_frequencies = [polish_result.get(letter, 0) for letter in all_letters]
    spanish_frequencies = [spanish_result.get(letter, 0) for letter in all_letters]
    english_frequencies = [english_result.get(letter, 0) for letter in all_letters]

    # The position of the bars

    x = range(len(all_letters))

    # Creating the bars

    plt.bar(x, polish_frequencies, width=0.3, label="Polish", color='#FFB3BA', align='center') 
    plt.bar([p + 0.3 for p in x], spanish_frequencies, width=0.3, label="Spanish", color='#FFDAC1', align='center') 
    plt.bar([p + 0.6 for p in x], english_frequencies, width=0.3, label="English", color='#B5EAD7', align='center') 


    # Tittles
    plt.xlabel('Letters', fontsize=14, fontname='monospace', weight='bold') 
    plt.ylabel('Frequency', fontsize=14, fontname='monospace',weight='bold')  
    plt.title('LETTER FREQUENCY COMPARISON', fontsize=18, fontname='monospace', weight='bold')  
    

    plt.xticks([p + 0.3 for p in x], all_letters, rotation=90)
    
    # Show the legend
    
    plt.legend()

    #Show the chart
    plt.tight_layout()
    plt.show()


print("Choose a language or option:")
print("1. Polish")
print("2. Spanish")
print("3. English")
print("4. Show Chart of all languages")
print("5. Exit")
choice = input("Insert here the number of your choice: ")


if choice == "1":
    show_frequency("Polish", "polish.txt")
elif choice == "2":
    show_frequency("Spanish", "spanish.txt")
elif choice == "3":
    show_frequency("English", "english.txt")
elif choice == "4":
    plot_chart()  
elif choice == "5":
    print("Bye!")
else:
    print("Invalid option")
