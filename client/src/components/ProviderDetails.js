import React from 'react';
import { useParams } from 'react-router-dom';

const ProviderDetails = () => {
  let { id } = useParams();

  return (
    <div>
      <h1>Provider Detail Page</h1>
      <p>Provider ID: {id}</p>
    </div>
  );
};

export default ProviderDetails;
