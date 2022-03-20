import axios from 'axios';
import React from 'react';
import PeopleTable from './components/PeopleTable';
import CreatePerson from './components/CreatePerson';
import CreateLanguage from './components/CreateLanguage';

const App = () => {
  const [peopleData, setPeopleData] = React.useState([]);
  const [peopleDataSorted, setPeopleDataSorted] = React.useState([]);
  const [sorted, setSorted] = React.useState(false);

  const [cityData, setCityData] = React.useState([]);
  const [languageData, setLanguageData] = React.useState([]);

  const [name, setName] = React.useState('');
  const [phone, setPhone] = React.useState('');
  const [city, setCity] = React.useState(1);

  const [person, setPerson] = React.useState(1);
  const [language, setLanguage] = React.useState(1);

  React.useEffect(() => {
    axios.get("/api/react", {
      headers: {
          accepts: "application/json",
        }, 
      })
      .then((response) => {
        setPeopleData(response.data);
      })
      .catch(err => console.log(err));

      axios.get("/api/reactcity", {
        headers: {
            accepts: "application/json",
          }, 
        })
        .then((response) => {
          setCityData(response.data);
        })
        .catch(err => console.log(err));

        axios.get("/api/reactlanguage", {
          headers: {
              accepts: "application/json",
            }, 
          })
          .then((response) => {
            setLanguageData(response.data);
          })
          .catch(err => console.log(err));
    }, []);

  const handleSubmit = (event) => {
    event.preventDefault();
    
    axios
      .post("api/react", {
        name: name,
        phoneNumber: phone,
        cityId: city,
      })
      .then(() => {
        setPeopleDataSorted([]);
        setSorted(false);
        setName('');
        setPhone('');
        setCity(1);
        axios.get("/api/react", {
          headers: {
              accepts: "application/json",
            }, 
          })
          .then((response) => {
            setPeopleData(response.data);
          })
          .catch(err => console.log(err));
      });
  }

  const handleLanguageSubmit = (event) => {
    event.preventDefault();
    
    axios
      .post("api/reactlanguage", {
        personRefId: person,
        languageRefId: language,
      })
      .then(() => {
        setPeopleDataSorted([]);
        setSorted(false);
        setPerson(1);
        setLanguage(1);
        axios.get("/api/react", {
          headers: {
              accepts: "application/json",
            }, 
          })
          .then((response) => {
            setPeopleData(response.data);
            alert("Språket tillagt!");
          })
          .catch(err => console.log(err));
      });
  }

  const handleSort = () => {
    if(sorted === false){
      let arrayToSort = peopleData;
      let sortedArray = arrayToSort.sort(function(a, b,) {
        const nameA = a.PersonDTOName.toUpperCase();
        const nameB = b.PersonDTOName.toUpperCase();
  
        if (nameA < nameB) {
          return -1;
        }
        if (nameA > nameB) {
          return 1;
        }
      
        return 0;
      });
  
      setPeopleDataSorted(sortedArray);
      setSorted(true);
    }
    else{
      setPeopleDataSorted([]);
      setSorted(false);

      axios.get("/api/react", {
        headers: {
            accepts: "application/json",
          }, 
        })
        .then((response) => {
          setPeopleData(response.data);
        })
        .catch(err => console.log(err));
    }
  }

  const handleSortRevert = () => {
    setPeopleDataSorted([]);
    setSorted(false);

    axios.get("/api/react", {
      headers: {
          accepts: "application/json",
        }, 
      })
      .then((response) => {
        setPeopleData(response.data);
      })
      .catch(err => console.log(err));
  }

  return(
    sorted 
    ?
    <div>
      <CreatePerson 
        name={name} 
        phone={phone} 
        city={city} 
        setName={setName} 
        setPhone={setPhone} 
        setCity={setCity}
        cityData={cityData} 
        handleSubmit={handleSubmit} />
      <br />
      <br />
      <CreateLanguage
        person={person}
        setPerson={setPerson}
        peopleData={peopleData}
        language={language}
        setLanguage={setLanguage}
        languageData={languageData}
        handleLanguageSubmit={handleLanguageSubmit} />
      <br />
      <br />
      <button onClick={handleSort}>Återställ</button>
      <PeopleTable peopleData={peopleDataSorted} handleSort={handleSortRevert} />
    </div>
    :
    <div>
      <CreatePerson 
        name={name} 
        phone={phone} 
        city={city} 
        setName={setName} 
        setPhone={setPhone} 
        setCity={setCity}
        cityData={cityData}
        handleSubmit={handleSubmit} />
      <br />
      <br />
      <CreateLanguage
        person={person}
        setPerson={setPerson}
        peopleData={peopleData}
        language={language}
        setLanguage={setLanguage}
        languageData={languageData}
        handleLanguageSubmit={handleLanguageSubmit} />
      <br />
      <br />
      <button onClick={handleSort}>Sortera</button>
      <PeopleTable peopleData={peopleData} handleSort={handleSortRevert} />
    </div>
    )
};

export default App