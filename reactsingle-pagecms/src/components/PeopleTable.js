import axios from 'axios';
import React from 'react';

const PeopleTableHeader = (props) => {
  return(
    props.isDetail ? 
    <thead>
      <tr>
        <th>Id</th>
        <th>Namn</th>
        <th>Telefon</th>
        <th>Stad</th>
        <th>Land</th>
        <th>Ta bort</th>
        <th>Språk</th>
        <th>Tillbaka</th>
      </tr>
      </thead>
        :
      <thead>
        <tr>
          <th>Id</th>
          <th>Namn</th>
          <th>Detaljer</th>
        </tr>
      </thead>
  )
}

const PersonDetail = (props) => {
  const languageRows = props.languages.map((languages, languageIndex) => {
    return(
      <td key={languageIndex}>{languages.LanguageName}</td>
    );
  });

  return(
    props.isLanguages 
    ?
      <>
        {languageRows}
        <td>
          <button onClick={() => props.handleClickReturnToDetails()}>Tillbaka till detaljer</button> 
        </td>
      </>
    :
      <>
        <td>{props.person.PersonDTOId}</td>
        <td>{props.person.PersonDTOName}</td>
        <td>{props.person.PersonDTOPhone}</td>
        <td>{props.person.PersonDTOCity}</td>
        <td>{props.person.PersonDTOCountry}</td>
        <td>
          <button onClick={ () => {props.handleClickDelete(props.person.PersonDTOId)}}>Ta bort</button>
        </td>
        <td>
          <button onClick={() => props.handleClickLanguages(props.person.PersonDTOId)}>Språk</button>
        </td>
        <td>
          <button onClick={function () {props.handleClickReturn(); props.handleSort(); }}>Tillbaka</button>
        </td>
      </>
  )
}

const PersonOverview = (props) => {
  return(
    <>
      <td>{props.person.PersonDTOId}</td>
      <td>{props.person.PersonDTOName}</td>
      <td>
        <button onClick={() => props.handleClick(props.index)}>Detaljer</button>
      </td>
    </>
  )
}

const PeopleTableBody = (props) => {
  const [isDetailArr, setDetailArr] = React.useState([]);
  const [isDetail, setDetail] = React.useState(false);
  const [languages, setLanguages] = React.useState([]);
  const [isLanguages, setIsLanguages] = React.useState(false);

  React.useEffect(() => {
    setDetailArr(props.peopleData);
  }, [props.peopleData]);
  
  const handleClick = (index) => {
    setDetailArr([props.peopleData[index]]);
    setDetail(true);
  }

  const handleClickDelete = (personId) => {
    axios.delete(`/api/react/${personId}`)
    .then(() => {
      axios.get("/api/react", {
        headers: {
            accepts: "application/json",
          }, 
        })
        .then((response) => {
          setDetailArr(response.data);
          setDetail(false);
        })
        .catch(err => console.log(err));
    })
    .catch(err => console.log(err));
  }

  const handleClickReturn = () => {
    axios.get("/api/react", {
      headers: {
          accepts: "application/json",
        }, 
      })
      .then((response) => {
        setDetailArr(response.data);
        setDetail(false);
      })
      .catch(err => console.log(err));
  }

  const handleClickLanguages = (personId) => {
    axios.get(`/api/react/${personId}`, {
      headers: {
      accpeted: "application/json",
    },
  })
  .then((response) => {
    setLanguages(response.data);
    setIsLanguages(true);
  })
  }

  const handleClickReturnToDetails = () => {
    setIsLanguages(false);
  }

  const peopleRows = isDetailArr.map((person, index) => {

      return(
        <tr key={index}>
          {isDetail
          ?
          <PersonDetail 
            person={person}
            languages={languages}
            isLanguages={isLanguages}
            handleClickDelete={handleClickDelete} 
            handleClickReturn={handleClickReturn} 
            handleClickLanguages={handleClickLanguages} 
            handleClickReturnToDetails={handleClickReturnToDetails}
            handleSort={props.handleSort}
            />
          :
          <PersonOverview 
            person={person} 
            index={index} 
            handleClick={handleClick}/>
          }
        </tr>
      );
    });
  
    return (
      <>
        <PeopleTableHeader isDetail={isDetail} />
        <tbody>{peopleRows}</tbody>
      </>
      ) 
}

const PeopleTable = (props) => {
  return(
      <table>
        <PeopleTableBody peopleData={props.peopleData} handleSort={props.handleSort} />
      </table>
  )
}

export default PeopleTable
